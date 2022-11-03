export class UserUpdate {
    
    constructor(
        public currentUserId: number = 0,
        public id:number=0,
        public firstName:string="",
        public lastName:string="",
        public passwordHash:string = ""
    ){}
}
