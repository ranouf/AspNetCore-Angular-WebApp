import { Component, ViewEncapsulation, OnInit, ChangeDetectorRef, HostBinding } from '@angular/core';
import { TdMediaService, TdLoadingService } from '@covalent/core';
import { Location } from '@angular/common';
import { slideInDownAnimation } from './../../animations';
import { FormBuilder, FormControl, FormGroup, Validators  } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SamplesService, MySampleDto } from './../../services/api.services';

@Component({
  selector: 'sample-edit',
  templateUrl: './sample-edit.component.html',
  animations: [slideInDownAnimation],
  providers: [FormBuilder],
})
export class SampleEditComponent implements OnInit {
  @HostBinding('@routeAnimation') routeAnimation = true;

  sampleForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private samplesService: SamplesService,
    private route: ActivatedRoute,
    private router: Router,
    private _location: Location,
    public media: TdMediaService,
    private loadingService: TdLoadingService,
    private _changeDetectionRef: ChangeDetectorRef
  ) {
    this.createForm();
  }

  createForm() {
    this.sampleForm = this.fb.group({
      // id: undefined,
      value: ['', Validators.required ],
    });
  }

  submit(): void {
    if (this.sampleForm.get('id')) {
      this.updateOffer();
    } else {
      this.createOffer();
    }
  }

  createOffer(): void {
    this.loadingService.register('sample');
    this.samplesService.createSample(this.sampleForm.value)
      .subscribe(result => {
        this.loadingService.resolve('sample');
        this.router.navigate(['/samples/list']);
      }, error => {
        console.log('Error SamplesService.createSample: ' + error);
        this.loadingService.resolve('sample');
      });
  }

  updateOffer(): void {
    this.loadingService.register('sample');
    this.samplesService.updateSample(this.sampleForm.value)
      .subscribe(result => {
          this.loadingService.resolve('sample');
          this.router.navigate(['/samples/list']);
      }, error => {
        console.log('Error SamplesService.updateSample: ' + error);
        this.loadingService.resolve('sample');
      });
  }

  cancel(): void {
    this._location.back();
  }

  loadData(id: string): void {
    this.loadingService.register('sample');
    this.samplesService.getSampleById(id)
      .subscribe(result => {
        this.sampleForm.addControl('id', new FormControl(''));
        this.sampleForm.setValue({
          id: result.id,
          value: result.value,
        });
        this.loadingService.resolve('sample');
      }, error => {
        console.log('Error SamplesService.getSample: ' + error);
        this.loadingService.resolve('sample');
      });
  }

   ngOnInit() {
    this.route.params.subscribe((params: { id: string }) => {
      if (params.id) {
        this.loadData(params.id);
      }
    });
   }

  ngAfterViewInit(): void {
    this._changeDetectionRef.detectChanges();
  }
}
