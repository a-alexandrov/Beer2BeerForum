export class UserComment {
    constructor(
        public id: number = 0,
        public username: string = '',
        public avatarImage: Blob = new Blob,
        public imageType: string = ''
        ) {
    }
}