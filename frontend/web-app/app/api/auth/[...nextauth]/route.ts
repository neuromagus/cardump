import DuendeIdentityServer6 from "next-auth/providers/duende-identity-server6"
import NextAuth, { NextAuthOptions } from "next-auth"

export const authOptions: NextAuthOptions = {
    session: {
        strategy: "jwt",
    },
    providers: [
        DuendeIdentityServer6({
            id: "id-server",
            clientId: "nextApp",
            clientSecret: "realsecret",
            issuer: "http://localhost:5000",
            authorization: { params: { scope: "openid profile auctionApp" } },
            idToken: true
        })
    ],
    callbacks: {
        async jwt({token, profile, account, user}) {
            console.log({token, profile, account, user})
            return token
        }
    }
}

const handler = NextAuth(authOptions)

export { handler as GET, handler as POST }