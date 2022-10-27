export class UserComment {
    constructor(
        public userId: number = 0,
        public username: string = '',
        public avatarImage: Blob = new Blob
        ) {
    }
}