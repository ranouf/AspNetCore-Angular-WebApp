import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { Router } from '@angular/router';

import * as _fromAngularMaterial from '@angular/material';
import * as _fromCovalent from '@covalent/core';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { RootComponent } from './components/root/root.component';
import { AuthenticationModule } from './components/authentication/authentication.module';
import { AuthenticationService } from './services/api.services';
import { AuthService } from './services/auth.service';
import { DashboardModule } from './components/dashboard/dashboard.module';
import { SamplesModule } from './components/samples/samples.module';

@NgModule({
	imports: [
		BrowserModule,
		FormsModule,
		HttpModule,
		BrowserAnimationsModule,

		//Angular Material
		_fromAngularMaterial.MaterialModule,
		_fromAngularMaterial.MdDatepickerModule,
		_fromAngularMaterial.MdNativeDateModule,
		_fromAngularMaterial.MdCoreModule,
		_fromAngularMaterial.MdSnackBarModule,
		_fromAngularMaterial.MdNativeDateModule,
		_fromAngularMaterial.MdDatepickerModule,
		//_fromAngularMaterial.MatCommonModule,,
   // _fromAngularMaterial.MaterialModule,

	//Covalent
	_fromCovalent.CovalentLayoutModule,
	_fromCovalent.CovalentStepsModule,
	_fromCovalent.CovalentMediaModule,
	_fromCovalent.CovalentLoadingModule,
	_fromCovalent.CovalentNotificationsModule,
	_fromCovalent.CovalentMenuModule,
	_fromCovalent.CovalentDialogsModule,
	_fromCovalent.CovalentSearchModule,
	_fromCovalent.CovalentPagingModule,
	_fromCovalent.CovalentFileModule,
	_fromCovalent.CovalentCommonModule,

		//Test1
		AppRoutingModule,
		AuthenticationModule,
		DashboardModule,
		SamplesModule,
	],
	declarations: [
		AppComponent,
    RootComponent,
	],
	providers: [
		AuthenticationService,
		AuthService
	],
	bootstrap: [AppComponent]
})
export class AppModule {
	// Diagnostic only: inspect router configuration
	constructor(router: Router) {
		console.log('Routes: ', JSON.stringify(router.config, undefined, 2));
	}
}
