Title: Media Queries in CSS – Min-Width and Max-Width
Published: 02/09/2018
Author: Ankush Jain
IsActive: true
Tags:
  - CSS
  - Bootstrap
  - Web Development
---
Media queries allow us to write device-specific CSS & build responsive websites. 

Media Queries are part of CSS3.

## Understand Media Query by Example:
Suppose, you are developing an application & want the application to look like a native app in mobile and tablet devices while maintaining the full view in the desktop & laptops devices as well. Here you can make use of media queries to write such CSS that will support all major devices and make your application responsive to all devices.

Media Query is just like an ordinary CSS, the only difference is that it is wrapped inside a `@media` block like below.

```css
@media (min-width: 576px) { 
	...
	... 
	Normal CSS
	...
	...
}
```

> I often used to get confused when to use `min-width` & when to use `max-width`. So, I thought to write a blog here & document my understanding so that I can look onto this blog whenever I get confused.

## Understand Min-Width
Here is an example of `min-width` media query:

```css
@media only screen and (min-width: 576px) {...}
```

Here, this query really means that - "if device width is greater than or equals to 576px, then apply the CSS defined in this block."

- **Mobile First approach** – `min-width` queries are normally used when we are writing our application to target mobile devices only, but still want a good desktop view of it.
- Above examples states that the specified block of media CSS will be applied only when the device width exceeds 576px or becomes equal to this. It means that above CSS will be applied whenever the application is opened in the larger devices. i.e. Tablet or Desktop.

## Understand Max-Width
Here is an example of `max-width` media query:

```csss
@media only screen and (max-width: 576px) {...}
```
Here, this query really means that - "if device width is less than or equals to 576px, then apply the CSS defined in this block."

- **Desktop First approach** – `max-width` queries are normally used when we are writing our application mainly to target desktop devices, but still want to keep the application responsive to small devices as well. i.e. Mobile, Tablets etc.
- Above example states that the specified block of media CSS will be applied only when the device width becomes 576px or less than this. It means that above CSS will be applied whenever the application is opened in mobile devices.

## Combining Min-Width and Max-Width
We can also combine both `min-width` & `max-width` to target a particular screen width:

```css
@media (min-width: 576px) and (max-width: 768px) { ... }
```

Above CSS will be applied to only those screens whose width is greater than 576px and less than 768px.

## Bootstrap uses below breakpoints to handle responsive designs:
For the given screen size or larger

```
// Small devices (landscape phones, 576px and up)
@media (min-width: 576px) { ... }

// Medium devices (tablets, 768px and up)
@media (min-width: 768px) { ... }

// Large devices (desktops, 992px and up)
@media (min-width: 992px) { ... }

// Extra large devices (large desktops, 1200px and up)
@media (min-width: 1200px) { ... }
```

For the given screen size or smaller

```
// Extra small devices (portrait phones, less than 576px)
@media (max-width: 575.98px) { ... }

// Small devices (landscape phones, 576px and up)
@media (min-width: 576px) and (max-width: 767.98px) { ... }

// Medium devices (tablets, 768px and up)
@media (min-width: 768px) and (max-width: 991.98px) { ... }

// Large devices (desktops, 992px and up)
@media (min-width: 992px) and (max-width: 1199.98px) { ... }

// Extra large devices (large desktops, 1200px and up)
@media (min-width: 1200px) { ... }
```

Click [here](https://getbootstrap.com/docs/4.1/layout/overview/#responsive-breakpoints) to check responsive breakpoints on bootstrap's website. 

                