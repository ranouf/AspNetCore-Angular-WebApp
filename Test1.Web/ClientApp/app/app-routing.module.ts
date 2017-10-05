import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CanDeactivateGuard }       from './services/can-deactivate-guard.service';
import { AuthGuard }                from './services/auth-guard.service';

import { RootComponent } from './components/root/root.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';

import { SelectivePreloadingStrategy } from './selective-preloading-strategy';


const appRoutes: Routes = [
  {
    path: '', component: RootComponent, children: [
      { path: '', component: DashboardComponent },
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
      {
        path: 'dashboard',
        loadChildren: 'app/components/dashboard/dashboard.module#DashboardModule'
      },
    ]
  }
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
