
import { Comment } from './comment.model';
import { Like } from './like.model';

export class Post {
    constructor(
        public id: number = 0,
        public title: string = '',
        public content: string = '',
        public userID: number = 0,
        public userName: string = '',
        public avatarImage: Blob = new Blob,
        public imageType: string = '',
        public createdOn: string = '',
        public postLikes: number = 0,
        public postDislikes: number = 0,
        public commentsCount: number = 0,
        public likes: Like[] = [],
        public tags: string[] = [],
        public comments: Comment[] = []) {
    }
}