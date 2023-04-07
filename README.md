# Instructions
## Vertical Scrollbar
1. Create a __Canvas__.
2. On the Canvas create an __empty GameObject__ (rename it to _VerticalScrollView_) and add a __Scroll Rect__ component to it.
3. At Scroll Rect you can change parameters:
    * Horizontal: uncheck
    * Movement type: Clamped
    * Inertia: uncheck
    * Scroll Sensitivity: 20 (or other as you wish)
4. Inside the VerticalScrollView create an __empty GameObject__ (rename it to _Content_).
5. Drop __Content__ to property Content in Scroll Rect that attached to VerticalScrollView.
6. Stretch Content, change a VerticalScrollView size and color (by adding __Image__ component) as you need.
7. Inside the Content create a content (images, buttons, etc.), change its color or add a source image.
8. Add __Grid Layout Group__ component to Content. Change parameters as you need. In __Constraint__ parameter check "Fixed Column Count" and write down number you need.
9. In VerticalScrollView create an __empty GameObject__ (rename it to _Mask_), drop Content into Mask, add __Image__ component (change its color or add source image) and __Mask__ component to Mask (uncheck __Show Mask Graphic__), stretch Mask and change its size.
10. Stretch Content size to allow it scrolling.
11. Add __Content Size Filter__ component to Content. Set "Preferred Size" in Vertical Fit.
12. In Container set __Pivot__  0.5 (at x axe) and 1 (at y axe).

## Horizontal Scrollbar
1. Create a __Canvas__.
2. On the Canvas create an __empty GameObject__ (rename it to _HorizontalScrollView_) and add a __Scroll Rect__ component to it.
3. At Scroll Rect you can change parameters:
    * Vertical: uncheck
    * Movement type: Clamped
    * Inertia: uncheck
    * Scroll Sensitivity: 20 (or other as you wish)
4. Inside the HorizontalScrollView create an __empty GameObject__ (rename it to _Content_).
5. Drop __Content__ to property Content in Scroll Rect that attached to HorizontalScrollView.
6. Stretch Content, change a HorizontalScrollView size and color (by adding __Image__ component) as you need.
7. Inside the Content create a content (images, buttons, etc.), change its color or add a source image.
8. Add __Grid Layout Group__ component to Content. Change parameters as you need. In __Constraint__ parameter check "Fixed Row Count" and write down number you need.
9. In HorizontalScrollView create an __empty GameObject__ (rename it to _Mask_), drop Content into Mask, add __Image__ component (change its color or add source image) and __Mask__ component to Mask (uncheck __Show Mask Graphic__), stretch Mask and change its size.
10. Stretch Content size to allow it scrolling.
11. Add __Content Size Filter__ component to Content. Set "Preferred Size" in Horizontal Fit.
12. In Container set __Pivot__  0 (at x axe) and 0.5 (at y axe).

## Menu Scrollbar
1. Create a new __Canvas__, change its color.
2. Add __Scroll View__ to the Canvas.
3. Change it size (it should be like a screen size) and color.
4. In Scroll View delete __Scrollbar Vertical__, change hight of __Scrollbar Horizontal__ to 0.
5. In Scroll Viev -> Viewport -> Content add content (in this case there are buttons).
6. Create __Button__, change its size and size of Content.
7. In Content add _Content Size Filter_ component. Set Horizontal Fit to "Preferred size".
8. In Content add _Horizontal Layout Group_ component. Set Child Alignment to "Middle Left", change spacing, left and right padding.
9. In Content dublicate Button 4 times (or more, as you need).
10. In Scroll View in _Scroll Rect_ component uncheck "Vertical".
11. Create a new script.
12. In code add logic you need.
13. Add script to Content.
14. Add _Scrollbar Horizontal_ to scrollbar field.