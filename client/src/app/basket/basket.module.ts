import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasketComponent } from './basket.component';
import { BaketRoutingModule } from './baket-routing.module';

@NgModule({
  declarations: [
    BasketComponent
  ],
  imports: [
    CommonModule,
    BaketRoutingModule
  ]
})
export class BasketModule { }
