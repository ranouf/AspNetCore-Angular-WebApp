import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { SampleListComponent } from './sample-list.component';

import { SampleService } from './../../services/api.services';

import { SamplesRoutingModule } from './samples-routing.module';

@NgModule({
	imports: [
		CommonModule,
		FormsModule,
		SamplesRoutingModule
	],
	declarations: [
		SampleListComponent,
	],
	providers: [SampleService]
})
export class SamplesModule { }
