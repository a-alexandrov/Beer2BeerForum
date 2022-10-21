export class Comment {
    constructor(
        public id: number = 0,
        public content: string = '',
        public userId: number = 0,
        public userName: string = '') {
    }
}