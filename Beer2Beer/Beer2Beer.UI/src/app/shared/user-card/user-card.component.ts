import { Component, Input } from '@angular/core';
import { User } from '../models/user.model';
import { Imageservice } from 'src/app/core/services/image.service';
import { Router } from '@angular/router';
import { SafeUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-user-card',
  templateUrl: './user-card.component.html',
  styleUrls: ['./user-card.component.css']
})

export class UserCardComponent {
  @Input() user!: User;

  constructor(public readonly imageService: Imageservice, private router: Router) { }

  onClick(){
    const route = "/user/edit/" + this.user.id;
    this.router.navigate([route]);
  }
}

