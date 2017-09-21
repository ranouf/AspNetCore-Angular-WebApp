import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { SampleListComponent } from './sample-list.component';

const samplesRoutes: Routes = [
	{ path: 'samples', component: SampleListComponent },
];

@NgModule({
	imports: [
		RouterModule.forChild(samplesRoutes)
	],
	exports: [
		RouterModule
	]
})
export class SamplesRoutingModule { }
