import type { AppProps } from 'next/app'
import localFont from 'next/font/local'

// Pour accéder au dossier public, précéder le dossier de /
import '@/styles/global.css'
// https://nextjs.org/docs/pages/api-reference/components/font#src
const myFont = localFont({ src: '../styles/fonts/Satoshi-Regular.woff2' })
 
export default function App({ Component, pageProps }: AppProps) {
  return (
      <main className={myFont.className}>
        <Component {...pageProps} />
      </main>
    ) 
    
}