import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AuthGuard } from './../../services/auth-guard.service';
import { AuthService } from './../../services/auth.service';

import { SampleListComponent } from './sample-list.component';
import { SampleViewComponent } from './sample-view.component';
import { SampleEditComponent } from './sample-edit.component';
import { SamplesService } from './../../services/api.services';
import { SamplesRoutingModule } from './samples-routing.module';

import * as _fromAngularMaterial from '@angular/material';
import { CdkTableModule } from '@angular/cdk/table';
import * as _fromCovalent from '@covalent/core';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
	imports: [
		CommonModule,
		FormsModule,
		SamplesRoutingModule,
		ReactiveFormsModule,
		_fromAngularMaterial.MatCardModule,
		_fromAngularMaterial.MatTableModule,
		_fromAngularMaterial.MatButtonModule,
		_fromAngularMaterial.MatIconModule,
		_fromAngularMaterial.MatMenuModule,
		_fromAngularMaterial.MatPaginatorModule,
		_fromAngularMaterial.MatSortModule,
		_fromAngularMaterial.MatInputModule,
		_fromAngularMaterial.MatListModule,
		_fromAngularMaterial.MatFormFieldModule,
		CdkTableModule,
		_fromCovalent.CovalentCommonModule,
		_fromCovalent.CovalentMediaModule,
		_fromCovalent.CovalentDialogsModule,
		_fromCovalent.CovalentLoadingModule,
	],
	declarations: [
		SampleListComponent,
		SampleViewComponent,
		SampleEditComponent,
	],
	providers: [
		SamplesService,
		AuthService,
		AuthGuard
	]
})
export class SamplesModule { }
