import { Component, ViewEncapsulation, OnInit, ChangeDetectorRef } from '@angular/core';

@Component({
	selector: 'sample-list',
	templateUrl: './sample-list.component.html'
})
export class SampleListComponent implements OnInit {
	constructor(
		private _changeDetectionRef: ChangeDetectorRef) {
	}

	ngOnInit() {
	}

	ngAfterViewInit(): void {
		this._changeDetectionRef.detectChanges();
	}
}
