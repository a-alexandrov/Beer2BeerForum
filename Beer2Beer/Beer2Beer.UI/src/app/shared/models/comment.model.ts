import { UserComment } from './user-comment.model';

export class Comment {
    constructor(
        public id: number = 0,
        public content: string = '',
        public user: UserComment = new UserComment,
        public createdOn: string = '',
        public postId: number = 0,
        ) {
    }
}