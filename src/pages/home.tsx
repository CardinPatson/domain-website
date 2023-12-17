import Pricing from "@/app/components/pricing"
import axios from "axios"
import { useEffect } from "react"
export default function Home() {
  useEffect(()=>{
    axios.post("http://localhost:5247/graphql", {
      query: `query{ contents{ contTitle, contDescription}}`
    },{
      withCredentials : true,
      headers: {
        'Content-Type': 'application/json'
      }
    }).then((data)=>{
      console.log(data);
    }).catch(err => {
      console.log(err);
    });

    axios.get("http://localhost:5247/api/v1/content",{withCredentials: true}).then((data)=>{
      console.log(data)
    }).catch(err => {
      console.log(err)
    })
  })
  return (
    <h1 className="text-3xl font-bold underline">
      <Pricing />
    </h1>
  )
}