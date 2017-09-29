import { Component, ViewEncapsulation, OnInit, ChangeDetectorRef, HostBinding } from '@angular/core';
import { slideInDownAnimation }   from './../../animations';

@Component({
	selector: 'dashboard',
	templateUrl: './dashboard.component.html',
  animations: [ slideInDownAnimation ]
})
export class DashboardComponent implements OnInit {
  @HostBinding('@routeAnimation') routeAnimation = true;

	constructor(
		private _changeDetectionRef: ChangeDetectorRef) {
	}

	ngOnInit() {
	}

	ngAfterViewInit(): void {
		this._changeDetectionRef.detectChanges();
	}
}
