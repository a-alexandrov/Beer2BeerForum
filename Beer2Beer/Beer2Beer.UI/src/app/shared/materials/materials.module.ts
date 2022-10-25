import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatButtonModule} from '@angular/material/button';
import {MatGridListModule} from '@angular/material/grid-list';



@NgModule({
  declarations: [],
  exports: [
    CommonModule,
    MatButtonModule,
    MatGridListModule
  ]
})
export class MaterialsModule { }
