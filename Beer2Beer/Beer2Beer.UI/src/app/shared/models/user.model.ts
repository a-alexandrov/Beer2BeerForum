
import {Comment} from './comment.model'
import {Post} from './post.model'

export class User {
    
    constructor(
        public id:number = 0,
        public isBlocked:boolean = false,
        public isAdmin:boolean = false,
        public firstName:string = "",
        public lastName:string = "",
        public username:string = "",
        public email: string = "",
        public avatarImage: Blob = new Blob,
        public imageType: string = '',
        public phoneNumber?:string,
        public posts: Post[] = [],
        public comments: Comment[] = []
    ){}

    
}

