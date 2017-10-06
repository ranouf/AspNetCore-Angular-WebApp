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

import * as _fromAngularMaterial from '@angular/material';
import * as _fromCovalent from '@covalent/core';

@NgModule({
	imports: [
		BrowserModule,
		FormsModule,
		HttpModule,
		BrowserAnimationsModule,
		NoConflictStyleCompatibilityMode,

		//Material
		_fromAngularMaterial.MatAutocompleteModule,
		_fromAngularMaterial.MatButtonModule,
		_fromAngularMaterial.MatButtonToggleModule,
		_fromAngularMaterial.MatCardModule,
		_fromAngularMaterial.MatCheckboxModule,
		_fromAngularMaterial.MatChipsModule,
		_fromAngularMaterial.MatCommonModule,  
		_fromAngularMaterial.MatDatepickerModule,
		_fromAngularMaterial.MatDialogModule,
		_fromAngularMaterial.MatExpansionModule,
		_fromAngularMaterial.MatFormFieldModule,
		_fromAngularMaterial.MatGridListModule,
		_fromAngularMaterial.MatIconModule,
		_fromAngularMaterial.MatInputModule,
		_fromAngularMaterial.MatLineModule,
		_fromAngularMaterial.MatListModule,
		_fromAngularMaterial.MatMenuModule,
		_fromAngularMaterial.MatNativeDateModule,
		_fromAngularMaterial.MatOptionModule,
		_fromAngularMaterial.MatPaginatorModule,
		_fromAngularMaterial.MatProgressBarModule,
		_fromAngularMaterial.MatProgressSpinnerModule,
		_fromAngularMaterial.MatPseudoCheckboxModule,
		_fromAngularMaterial.MatRadioModule,
		_fromAngularMaterial.MatRippleModule,
		_fromAngularMaterial.MatSelectModule,
		_fromAngularMaterial.MatSidenavModule,
		_fromAngularMaterial.MatSliderModule,
		_fromAngularMaterial.MatSlideToggleModule,
		_fromAngularMaterial.MatSnackBarModule,
		_fromAngularMaterial.MatSortModule,
		_fromAngularMaterial.MatStepperModule,
		_fromAngularMaterial.MatTableModule,
		_fromAngularMaterial.MatTabsModule,
		_fromAngularMaterial.MatToolbarModule,
		_fromAngularMaterial.MatTooltipModule,       

    //Covalent
		_fromCovalent.CovalentChipsModule,
		_fromCovalent.CovalentCommonModule,
		_fromCovalent.CovalentDataTableModule,
		_fromCovalent.CovalentDialogsModule,
		_fromCovalent.CovalentExpansionPanelModule,
		_fromCovalent.CovalentFileModule,
		_fromCovalent.CovalentJsonFormatterModule,
		_fromCovalent.CovalentLayoutModule,
		_fromCovalent.CovalentLoadingModule,
		_fromCovalent.CovalentMediaModule,
		_fromCovalent.CovalentMenuModule,
		_fromCovalent.CovalentMessageModule,
		_fromCovalent.CovalentNotificationsModule,
		_fromCovalent.CovalentPagingModule,
		_fromCovalent.CovalentSearchModule,
		_fromCovalent.CovalentStepsModule,
		_fromCovalent.CovalentVirtualScrollModule,


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
