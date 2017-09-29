import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AuthGuard }            from './../../services/auth-guard.service';
import { AuthService }          from './../../services/auth.service';

import { SampleListComponent } from './sample-list.component';
import { SamplesService } from './../../services/api.services';
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
	providers: [
    SamplesService,
    AuthService,
    AuthGuard
  ]
})
export class SamplesModule { }
