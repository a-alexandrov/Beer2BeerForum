export class PostLike {
    constructor(
        public userID: number = 0,
        public postID: number = 0,
        public isLiked: boolean,
    ) { }
}