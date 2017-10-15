import { Component, ViewEncapsulation, OnInit, ChangeDetectorRef, HostBinding } from '@angular/core';
import { Location } from '@angular/common';
import { TdMediaService, TdLoadingService } from '@covalent/core';
import { slideInDownAnimation } from './../../animations';
import { ActivatedRoute } from '@angular/router';
import { SamplesService, MySampleDto } from './../../services/api.services';

@Component({
   selector: 'sample-view',
   templateUrl: './sample-view.component.html',
   animations: [slideInDownAnimation]
})
export class SampleViewComponent implements OnInit {
   @HostBinding('@routeAnimation') routeAnimation = true;

  sample: MySampleDto = <MySampleDto>{};

   constructor(
    private samplesService: SamplesService,
    private route: ActivatedRoute,
    public media: TdMediaService,
    private loadingService: TdLoadingService,
    private _location: Location,
    private _changeDetectionRef: ChangeDetectorRef,
   ) {
   }

  cancel(): void {
        this._location.back();
  }

  loadData(id: string): void {
    this.loadingService.register('sample');
    this.samplesService.getSampleById(id)
      .subscribe(result => {
        this.sample = result;
        this.loadingService.resolve('sample');
      }, error => {
        console.log('Error SamplesService.getSample: ' + error);
        this.loadingService.resolve('sample');
      });
  }

   ngOnInit() {
    this.route.params.subscribe((params: { id: string }) => {
      this.loadData(params.id);
    });
   }

   ngAfterViewInit(): void {
    this.media.broadcast();

    this._changeDetectionRef.detectChanges();
   }
}
