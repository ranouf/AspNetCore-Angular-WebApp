import { Component, OnInit } from '@angular/core';
import { TdMediaService } from '@covalent/core';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
	isLoggedIn = false;

	constructor(
		public media: TdMediaService,
		private _authService: AuthService,
	) {
	}

	logout(): void {
		this._authService.logout();
	}

	ngOnInit() {
		this.isLoggedIn = this._authService.isLoggedIn();
	}

	ngAfterViewInit(): void {
		this.media.broadcast();
	}
}
