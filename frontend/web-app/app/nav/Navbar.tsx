import Search from "./Search";
import Logo from "./Logo";
import LoginButton from "./LoginButton";
import { getCurrentUser } from "../actions/authAction";
import UserActions from "./UserActions";

export default async function Navbar() {
    const user = await getCurrentUser() 
     
    return (
        <header className="sticky top-0 z-50 md:xl:flex
                           md:xl:justify-around bg-white md:xl:p-5 p-3 item-center text-gray-800
                           shadow-md">
            <Logo />
            <Search />
            {user ? (
                <UserActions user={user} />
            ): (
                <LoginButton />
            )}
            
        </header>
    )
}