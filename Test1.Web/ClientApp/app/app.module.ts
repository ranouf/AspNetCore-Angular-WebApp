import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { Router } from '@angular/router';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { AuthenticationModule } from './components/authentication/authentication.module';
import { AuthenticationService } from './services/api.services';
import { AuthService } from './services/auth.service';
import { DashboardModule } from './components/dashboard/dashboard.module';
import { SamplesModule } from './components/samples/samples.module';
import { NoConflictStyleCompatibilityMode } from '@angular/material'

@NgModule({
	imports: [
		BrowserModule,
		FormsModule,
		HttpModule,
		BrowserAnimationsModule,
    NoConflictStyleCompatibilityMode,

		//Test1
		AppRoutingModule,
		AuthenticationModule,
		DashboardModule,
		SamplesModule,
	],
	declarations: [
		AppComponent
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
