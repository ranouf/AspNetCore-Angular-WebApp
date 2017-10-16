import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { MyProfileComponent } from './my-profile.component';

import { AuthGuard } from './../../services/auth-guard.service';

const loginRoutes: Routes = [
	{ path: 'profile/my-profile', component: MyProfileComponent, canActivate: [AuthGuard] },
];

@NgModule({
	imports: [
		RouterModule.forChild(loginRoutes)
	],
	exports: [
		RouterModule
	]
})
export class ProfileRoutingModule { }
