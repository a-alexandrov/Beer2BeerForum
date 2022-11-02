import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-input-modal-form',
  templateUrl: './input-modal-form.component.html',
  styleUrls: ['./input-modal-form.component.css']
})
export class InputModalFormComponent implements OnInit {

  public input: string = '';
  public message: string = '';
  public currentValue: string = '';

  constructor(
    public dialogRef: MatDialogRef<InputModalFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }

  ngOnInit(): void {
    this.message = this.data.message;
    this.currentValue = this.data.currentValue;
  }

  onClick(){
    if(!this.data.isPassword && (this.input.length < this.data.minValue || this.input.length > this.data.maxValue) )
    {
        this.input = this.currentValue;
    }

    this.dialogRef.close(this.input);
  }
}
