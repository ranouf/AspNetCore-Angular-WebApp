import { Component, ViewEncapsulation, OnInit, ChangeDetectorRef, HostBinding } from '@angular/core';
import { slideInDownAnimation } from './../../animations';
import { AuthService } from './../../services/auth.service';
import { AuthenticationService } from './../../services/api.services';

@Component({
	selector: 'sample-list',
	templateUrl: './sample-list.component.html',
	animations: [slideInDownAnimation]
})
export class SampleListComponent implements OnInit {
	@HostBinding('@routeAnimation') routeAnimation = true;

	constructor(
		private _authService: AuthService,
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
				console.trace('Success - AuthenticationService.Test');
			}, error => {
				console.log('Error - AuthenticationService.Test');
			});
	}

	ngOnInit() {
	}

	ngAfterViewInit(): void {
		this._changeDetectionRef.detectChanges();
	}
}
