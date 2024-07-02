import Search from "./Search";
import Logo from "./Logo";

export default function Navbar() {
    return (
        <header className="sticky top-0 z-50 md:xl:flex 
                           justify-around bg-white p-5 item-center text-gray-800
                           shadow-md">
            <Logo />
            <Search />
            Login
        </header>
    )
}