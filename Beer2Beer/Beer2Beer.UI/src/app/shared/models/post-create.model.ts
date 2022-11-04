export class PostCreate {
    constructor(
        public userID: number = 0,
        public title: string = '',
        public content: string = '',
    ) { }
}