import { NgModule }       from '@angular/core';
import { BrowserModule }  from '@angular/platform-browser';
import { FormsModule }    from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { Router } from '@angular/router';

import { AppComponent }            from './app.component';
import { AppRoutingModule }        from './app-routing.module';

import { DashboardModule } from './components/dashboard/dashboard.module';
import { SamplesModule } from './components/samples/samples.module';

@NgModule({
	imports: [
		BrowserModule,
		FormsModule,
		BrowserAnimationsModule,

    //Test1
		AppRoutingModule,
    DashboardModule,
    SamplesModule,
	],
	declarations: [
		AppComponent
	],
	providers: [],
	bootstrap: [AppComponent]
})
export class AppModule {
	// Diagnostic only: inspect router configuration
	constructor(router: Router) {
		console.log('Routes: ', JSON.stringify(router.config, undefined, 2));
	}
}
