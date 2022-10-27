import { Component, Input} from '@angular/core';
import { User } from '../models/user.model';
import { Imageservice } from 'src/app/core/services/image.service';
@Component({
  selector: 'app-user-card',
  templateUrl: './user-card.component.html',
  styleUrls: ['./user-card.component.css']
})
export class UserCardComponent {
  @Input() user!: User;
  
  constructor(public readonly imageService: Imageservice){}

  ngOnInit(): void {}
}

