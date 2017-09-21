import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { SelectivePreloadingStrategy } from './selective-preloading-strategy';


const appRoutes: Routes = [
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
		SelectivePreloadingStrategy
	]
})
export class AppRoutingModule { }
