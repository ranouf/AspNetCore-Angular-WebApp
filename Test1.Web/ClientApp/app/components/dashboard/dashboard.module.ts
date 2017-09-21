import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MdInputModule, MdCardModule, MdButtonModule } from '@angular/material';
import { CovalentLayoutModule, CovalentMessageModule, CovalentSearchModule } from '@covalent/core';

import { DashboardComponent } from './dashboard.component';
import { DashboardRoutingModule } from './dashboard-routing.module';

@NgModule({
	imports: [
		CommonModule,
		MdInputModule,
		MdCardModule,
		MdButtonModule,
		CovalentLayoutModule,
		CovalentMessageModule,
		CovalentSearchModule,
		DashboardRoutingModule
	],
	declarations: [
		DashboardComponent,
	],
	providers: []
})
export class DashboardModule { }
