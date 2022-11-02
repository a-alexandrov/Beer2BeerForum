import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-upload-avatar-modal',
  templateUrl: './upload-avatar-modal.component.html',
  styleUrls: ['./upload-avatar-modal.component.css']
})
export class UploadAvatarModalComponent implements OnInit {
  fileToUpload!: any;
  warning!: string;
  url!: string | ArrayBuffer | null;

  constructor(
    public dialogRef: MatDialogRef<UploadAvatarModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }

  ngOnInit(): void {
  }

  handleFileInput(event: any) {
    if(event !== null)
    {
      this.fileToUpload = event.target.files[0];
    }

    if (this.fileToUpload.length === 0)
          return;

      const mimeType = this.fileToUpload.type;

      if (mimeType.match(/image\/*/) == null) {
          this.warning = "Only images are supported.";
          return;
      }

      const reader = new FileReader();
      reader.readAsDataURL(this.fileToUpload); 
      reader.onload = (_event) => { 
          this.url = reader.result; 
      }
      console.log(this.warning);
  }

  onClick(){
    this.dialogRef.close(this.url);
  }
}
