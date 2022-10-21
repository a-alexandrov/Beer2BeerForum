
import { Comment } from './comment.model';

export class Post {
    constructor(
        public id: number = 0,
        public title: string = '',
        public content: string = '',
        public userId: number = 0,
        public likes: number = 0,
        public dislikes: number = 0,
        public commentsCount: number = 0,
        public tags: string[] = [],
        public comments: Comment[] = []) {
    }
}