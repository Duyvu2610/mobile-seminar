package matcha.project.be.enums;

import jakarta.annotation.Nonnull;
import lombok.*;
import lombok.experimental.FieldDefaults;
import org.springframework.http.HttpStatus;

@Getter
@FieldDefaults(level = AccessLevel.PRIVATE, makeFinal = true)
@RequiredArgsConstructor
public enum ItemError {
    ITEM_NOT_FOUND("Item not found", HttpStatus.NOT_FOUND);
    String message;
    HttpStatus httpStatus;
}
