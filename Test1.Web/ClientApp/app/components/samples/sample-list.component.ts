import { Component, ViewEncapsulation, OnInit, ChangeDetectorRef, HostBinding } from '@angular/core';
import { TdMediaService } from '@covalent/core';
import { slideInDownAnimation } from './../../animations';
import { AuthService } from './../../services/auth.service';
import { AuthenticationService, SamplesService, MySampleDto } from './../../services/api.services';
import {DataSource} from '@angular/cdk/collections';
import { Http } from '@angular/http';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import {Observable} from 'rxjs/Rx';

@Component({
	selector: 'app-sample-list',
	templateUrl: './sample-list.component.html',
  providers: [SamplesService],
	animations: [slideInDownAnimation]
})
export class SampleListComponent implements OnInit {
	@HostBinding('@routeAnimation') routeAnimation = true;
  sampleDataSource: SampleDataSource = <SampleDataSource>{};

	constructor(
		private _authService: AuthService,
    private samplesService: SamplesService,
		public media: TdMediaService,
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

	ngOnInit() {
    this.sampleDataSource = new SampleDataSource(this.samplesService);
	}

	ngAfterViewInit(): void {
		this.media.broadcast();
		this._changeDetectionRef.detectChanges();
	}
}

export class SampleDataSource extends DataSource<MySampleDto> {
  constructor(private samplesService: SamplesService) {
      super();
  }

  subject: BehaviorSubject<MySampleDto[]> = new BehaviorSubject<MySampleDto[]>([]);

  connect(): Observable<MySampleDto[]> {
      if (!this.subject.isStopped) {
        this.samplesService.getSamples()
        .subscribe(result => {
          this.subject.next(result);
        }, error => {
          console.log('Error SamplesService.getSamples: ' + error);
          this.subject.error(error);
        });
      }
      return Observable.merge(this.subject);
  }

  disconnect() {
      this.subject.complete();
      this.subject.observers = [];
  }
}
