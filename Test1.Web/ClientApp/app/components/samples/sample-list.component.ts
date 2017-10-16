import { Component, ViewEncapsulation, OnInit, ChangeDetectorRef, HostBinding } from '@angular/core';
import { TdMediaService, TdDialogService, TdLoadingService } from '@covalent/core';
import { slideInDownAnimation } from './../../animations';
import { AuthService } from './../../services/auth.service';
import { AuthenticationService, SamplesService, MySampleDto } from './../../services/api.services';
import { DataSource } from '@angular/cdk/collections';
import { Http } from '@angular/http';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Rx';
import { Subject } from 'rxjs/Subject';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import {PageEvent} from '@angular/material';
import {Sort} from '@angular/material';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sample-list',
  templateUrl: './sample-list.component.html',
  providers: [SamplesService],
  animations: [slideInDownAnimation]
})
export class SampleListComponent implements OnInit {
  @HostBinding('@routeAnimation') routeAnimation = true;

  columnKeys = ['value', 'creationTime', 'lastModificationTime', 'actions'];
  dataSource: SampleDataSource = <SampleDataSource>{};
  subject = new BehaviorSubject<MySampleDto[]>(undefined);

  selectedRowIndex = '';
  pageSize = 5;
  pageIndex = 0;
  length = 0;
  sort = '';
  direction = '';
  filter = '';
  filterSubject= new Subject<string>();

  constructor(
    private _authService: AuthService,
    private samplesService: SamplesService,
    public media: TdMediaService,
    private dialogService: TdDialogService,
    private loadingService: TdLoadingService,
    private router: Router,
    private _authenticationService: AuthenticationService,
    private _changeDetectionRef: ChangeDetectorRef
  ) {
    this.filterSubject
      .debounceTime(300)
      .distinctUntilChanged()
      .subscribe(filter => this.filterData(filter));
  }

  select(sample: MySampleDto) {
    this.router.navigate(['/samples/view/' + sample.id]);
  }

  changeFilter(filter: string): void {
    this.filterSubject.next(filter);
  }

  changePage(pageEvent: PageEvent): void {
    this.pageSize = pageEvent.pageSize;
    this.pageIndex = pageEvent.pageIndex;
    this.loadData();
  }

  filterData(filter: string): void {
    this.filter = filter;
    this.loadData();
  }

  sortData(sort: Sort): void {
    this.sort = sort.active;
    this.direction = sort.direction;
    this.loadData();
  }

  loadData(): void {
    this.loadingService.register('samples');
    this.samplesService.getSamples(
      this.pageSize,
      this.pageIndex,
      this.sort,
      this.direction,
      this.filter
    )
      .subscribe(result => {
        this.length = result.length;
        this.subject.next(result.items);
        this.loadingService.resolve('samples');
      }, error => {
        console.log('Error SamplesService.getSamples: ' + error);
        this.subject.error(error);
        this.loadingService.resolve('samples');
      });
  }

  deleteItem(sample: MySampleDto): void {
    this.dialogService
      .openConfirm({ message: 'Are you sure you want to delete this sample?' })
      .afterClosed().subscribe((confirm: boolean) => {
        if (confirm) {
          this.loadingService.register('samples');
          this.samplesService.deleteSample(sample.id)
            .subscribe(result => {
              this.loadData();
              this.loadingService.resolve('samples');
            }, error => {
              console.log('Error samplesService.deleteSample: ' + error);
              this.loadingService.resolve('samples');
            });
        }
      });
  }

  ngOnInit(): void {
    this.dataSource = new SampleDataSource(this.subject);
    this.loadData();
  }

  ngAfterViewInit(): void {
    this.media.broadcast();
    this._changeDetectionRef.detectChanges();
  }
}

export class SampleDataSource extends DataSource<MySampleDto> {
  constructor(
    private subject: BehaviorSubject<MySampleDto[]>
  ) {
      super();
  }

  connect(): Observable<MySampleDto[]> {
      return this.subject.asObservable();
  }

  disconnect() {}
}
