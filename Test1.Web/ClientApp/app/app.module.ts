import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MdButtonModule, MdCheckboxModule, MdInputModule } from '@angular/material';

import { CovalentLayoutModule, CovalentStepsModule, CovalentMessageModule, CovalentSearchModule } from '@covalent/core';

import { Sample } from './services/api.services';

@NgModule({
	declarations: [
		AppComponent
	],
	imports: [
		BrowserModule,
		BrowserAnimationsModule,
		MdButtonModule,
		MdCheckboxModule,
		MdInputModule,

		//Covalent
		CovalentLayoutModule,
		CovalentStepsModule,
		CovalentMessageModule,
		CovalentSearchModule,
	],
	providers: [Sample],
	bootstrap: [AppComponent]
})
export class AppModule { }
