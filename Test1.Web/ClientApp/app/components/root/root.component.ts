import { Component } from '@angular/core';
import { TdMediaService} from '@covalent/core';

@Component({
	selector: 'root',
	templateUrl: 'root.component.html',
	styleUrls: ['root.component.scss']
})
export class RootComponent {

	constructor(
    public media: TdMediaService,
	) {
	}

	ngAfterViewInit(): void {
    this.media.broadcast();
	}
}
