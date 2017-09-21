import { Component, ViewEncapsulation, OnInit, ChangeDetectorRef } from '@angular/core';

@Component({
	selector: 'dashboard',
	templateUrl: './dashboard.component.html'
})
export class DashboardComponent implements OnInit {
	constructor(
		private _changeDetectionRef: ChangeDetectorRef) {
	}

	ngOnInit() {
	}

	ngAfterViewInit(): void {
		this._changeDetectionRef.detectChanges();
	}
}
