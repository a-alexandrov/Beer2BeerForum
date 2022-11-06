export class CommentCreate{
    constructor(
        public content:string = '',
        public postID:number = 0,
        public userID:number = 0,
    ){}
}