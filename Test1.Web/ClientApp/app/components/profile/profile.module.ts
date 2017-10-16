import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { MatInputModule, MatCardModule, MatButtonModule } from '@angular/material';
import { CovalentLayoutModule, CovalentMessageModule, CovalentSearchModule, CovalentMediaModule } from '@covalent/core';

import { MyProfileComponent } from './my-profile.component';
import { ProfileRoutingModule } from './profile-routing.module';

@NgModule({
	imports: [
		CommonModule,
    FormsModule,
		MatInputModule,
		MatCardModule,
		MatButtonModule,
		CovalentLayoutModule,
		CovalentMessageModule,
		CovalentSearchModule,
		CovalentMediaModule,
		ProfileRoutingModule
	],
	declarations: [
		MyProfileComponent,
	],
	providers: []
})
export class ProfileModule { }
