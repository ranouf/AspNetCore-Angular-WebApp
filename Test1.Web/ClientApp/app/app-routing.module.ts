import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CanDeactivateGuard }       from './services/can-deactivate-guard.service';
import { AuthGuard }                from './services/auth-guard.service';

import { SelectivePreloadingStrategy } from './selective-preloading-strategy';


const appRoutes: Routes = [
  {
    path: 'authentication',
    loadChildren: 'app/components/authentication/authentication.module#AuthenticationModule',
    data: { preload: true }
  },
  {
    path: 'samples',
    loadChildren: 'app/components/samples/samples.module#SamplesModule',
    canLoad: [AuthGuard]
  },
	{ path: '', redirectTo: '/dashboard', pathMatch: 'full' },
];

@NgModule({
	imports: [
		RouterModule.forRoot(
			appRoutes,
			{
				enableTracing: true, // <-- debugging purposes only
				preloadingStrategy: SelectivePreloadingStrategy,
			}
		)
	],
	exports: [
		RouterModule
	],
	providers: [
    CanDeactivateGuard,
		SelectivePreloadingStrategy
	]
})
export class AppRoutingModule { }
