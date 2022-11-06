import { Like } from "./like.model";

export class LikesDto {
    constructor(
        public likes: Like[] = [],
        public postLikes: number = 0,
        public postDislikes: number = 0
    ) { }
}