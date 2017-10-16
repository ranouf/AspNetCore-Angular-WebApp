import { Component, ViewEncapsulation, OnInit, ChangeDetectorRef, HostBinding } from '@angular/core';
import { slideInDownAnimation } from './../../animations';
import { RegistrationDto, AccountService } from './../../services/api.services';
import { Router } from '@angular/router';
import { ErrorInfo } from './../../common/errorInfo';
import { Location } from '@angular/common';

@Component({
	selector: 'my-profile',
	templateUrl: './my-profile.component.html',
	providers: [AccountService],
	animations: [slideInDownAnimation]
})
export class MyProfileComponent implements OnInit {
	@HostBinding('@routeAnimation') routeAnimation = true;
	public registration: RegistrationDto = <RegistrationDto>{};
	private error: ErrorInfo;

	constructor(
		private accountService: AccountService,
		private _location: Location,
		private router: Router,
		private _changeDetectionRef: ChangeDetectorRef,
	) {
	}

	cancel(): void {
		this._location.back();
	}

	submit() {
		this.accountService.register(this.registration)
			.subscribe(result => {
				this.router.navigate(['/login']);
			}, error => {
				this.error = error;
				console.log('Error - AuthenticationService.register: ' + error);
			});
	}

	ngOnInit() {
	}

	ngAfterViewInit(): void {
		this._changeDetectionRef.detectChanges();
	}
}
