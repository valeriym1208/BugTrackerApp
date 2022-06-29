import React from 'react'
import cl from '../Select/Select.module.css'
const Select = (props:any) => {
  return (
    <select className={cl.select} name="members" id="members-select" {...props}>
      <option value="Valeriy Mashkin">Valeriy Mashkin</option>
      <option value="Daniil Beksovski">Daniil Beksovski</option>
      <option value="Nikita Myslitsky">Nikita Myslitsky</option>
      <option value="Nikita Myslitsky">Nikita Myslitsky</option>
      <option value="Nikita Myslitsky">Nikita Myslitsky</option>
    </select>
  )

}
export default Select
