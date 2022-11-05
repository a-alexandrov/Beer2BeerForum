export class UserUpdate {
    
    constructor(
        public currentUserId: number = 0,
        public id?:number,
        public firstName?: string,
        public lastName?: string,
        public passwordHash?: string,
        public phoneNumber?: string
    ){}
}
