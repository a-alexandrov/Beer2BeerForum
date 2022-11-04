export class PostUpdate {
    constructor(
        public id:number=0,
        public userID: number = 0,
        public title: string = '',
        public content: string = '',
    ) { }
}