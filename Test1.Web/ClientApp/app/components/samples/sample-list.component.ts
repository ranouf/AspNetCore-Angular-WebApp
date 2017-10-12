import { Component, ViewEncapsulation, OnInit, ChangeDetectorRef, HostBinding } from '@angular/core';
import { TdMediaService, TdDialogService, TdLoadingService } from '@covalent/core';
import { slideInDownAnimation } from './../../animations';
import { AuthService } from './../../services/auth.service';
import { AuthenticationService, SamplesService, MySampleDto } from './../../services/api.services';
import { DataSource } from '@angular/cdk/collections';
import { Http } from '@angular/http';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Rx';
import {PageEvent} from '@angular/material';

@Component({
	selector: 'app-sample-list',
	templateUrl: './sample-list.component.html',
  providers: [SamplesService],
	animations: [slideInDownAnimation]
})
export class SampleListComponent implements OnInit {
	@HostBinding('@routeAnimation') routeAnimation = true;

  dataSource: SampleDataSource = <SampleDataSource>{};
  subject = new BehaviorSubject<MySampleDto[]>([]);

  pageSize = 5;
  pageIndex = 0;
  length = 0;

	constructor(
		private _authService: AuthService,
    private samplesService: SamplesService,
		public media: TdMediaService,
    private dialogService: TdDialogService,
    private loadingService: TdLoadingService,
		private _authenticationService: AuthenticationService,
		private _changeDetectionRef: ChangeDetectorRef
	) {
	}

	logout() {
		this._authService.logout();
	}

	test() {
		this._authenticationService.test()
			.subscribe(result => {
				// console.trace('Success - AuthenticationService.Test');
			}, error => {
				console.log('Error - AuthenticationService.Test');
			});
	}

  changePage(pageEvent: PageEvent): void {
    this.pageSize = pageEvent.pageSize;
    this.pageIndex = pageEvent.pageIndex;

    this.loadSamples();
  }

  loadSamples(): void {
    this.loadingService.register('samples');
    this.samplesService.getSamples(
      this.pageSize,
      this.pageIndex
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

  delete(sample: MySampleDto): void {
      this.dialogService
          .openConfirm({ message: 'Are you sure you want to delete this sample?' })
          .afterClosed().subscribe((confirm: boolean) => {
              if (confirm) {
                  this.loadingService.register('samples');
                  this.samplesService.deleteSample(sample.id)
                      .subscribe(result => {
                        this.loadSamples();
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
    this.loadSamples();
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
