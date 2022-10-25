import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatToolbarModule } from '@angular/material/toolbar';



@NgModule({
  declarations: [],
  exports: [
    CommonModule,
    MatButtonModule,
    MatGridListModule,
    MatToolbarModule
  ]
})
export class MaterialsModule { }
