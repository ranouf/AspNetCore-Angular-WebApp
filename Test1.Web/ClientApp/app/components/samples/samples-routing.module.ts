import { NgModule }  from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { SampleListComponent } from './sample-list.component';
import { SampleViewComponent } from './sample-view.component';
import { SampleEditComponent } from './sample-edit.component';

import { AuthGuard }  from './../../services/auth-guard.service';

const samplesRoutes: Routes = [
  {path: 'samples/list', component: SampleListComponent, canActivate: [AuthGuard] },
  {path: 'samples/view/:id', component: SampleViewComponent, canActivate: [AuthGuard] },
  {path: 'samples/edit/:id', component: SampleEditComponent, canActivate: [AuthGuard] },
  {path: 'samples/add', component: SampleEditComponent, canActivate: [AuthGuard] },
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
